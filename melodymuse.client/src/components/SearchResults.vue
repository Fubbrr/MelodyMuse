<template>
    <div class="results-container">
        <div v-if="results.length" class="results-list">
            <ul>
                <li v-for="result in results" :key="result.id" class="result-item">
                    <!-- 根据类型显示不同的结果，并添加链接 -->
                    <span v-if="result.type === 'artist'" class="artist-name">
                        <a @click="goToArtistPage(result.artistId)" class="artist-link">{{ result.artistName }}</a>
                    </span>
                    <span v-if="result.type === 'song'" class="song-name">
                        <a @click.prevent="gotoPlay(result.songId)" class="song-link">{{ result.songName }}</a>
                    </span>

                    <!-- 根据类型显示不同的介绍或信息 -->
                    <span v-if="result.type === 'artist'" class="artist-intro">{{ result.artistIntro }}</span>
                    <span v-if="result.type === 'song'" class="album-name">{{ result.albumName }}</span>
                </li>
            </ul>
        </div>
        <div v-else class="no-results">
            没有找到相关结果
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            results: {
                type: Array,
                required: true
            }
        },
        methods: {
            gotoPlay(song) {
                this.$store.commit('addSongToList', song);

                // 更新当前播放的歌曲 ID
                this.$store.commit('setId', song);
                try {
                    // 使用 Vue Router 导航到播放页面，传递歌曲 ID 和相关的歌曲列表
                    const songList = song;
                    this.$router.push({
                        name: 'mediaplayer',
                        params: {
                            songId: song, // 当前播放的歌曲 ID
                            songList: songList  // 歌曲列表的所有 songId
                        }
                    });
                } catch (error) {
                    console.error('跳转到播放页面失败:', error);
                }
            },
            // 跳转到艺术家详情
            goToArtistPage(artistId) {
                this.$router.push({ name: "SingerDetail", params: { artistId: artistId } });
            },
        }
    }
</script>

<style scoped>
    .results-container {
        margin: 20px;
        margin-top: 10px;
    }

    .results-list ul {
        list-style: none;
        padding: 0;
    }

    .result-item {
        padding: 10px;
        border-bottom: 1px solid #cacaca;
        display: flex;
        justify-content: space-between;
        align-items: center;
        font-size: 14px; /* 设置字体大小为12px */
    }

    .artist-name, .song-name {
        font-weight: bold;
        font-size: 14px; /* 调整字体大小 */
    }

    .artist-intro, .album-name {
        font-size: 14px; /* 调整字体大小 */
    }

    .artist-link, .song-link {
        color: #284da0c1; /* 链接颜色 */
        text-decoration: none; /* 移除下划线 */
        font-size: 14px; /* 调整链接字体大小 */
    }

        .artist-link:hover, .song-link:hover {
            text-decoration: underline; /* 悬停时显示下划线 */
            background-color: transparent; /* 背景色保持透明 */
        }

    .no-results {
        padding: 20px;
        text-align: center;
        font-size: 14px; /* 调整无结果提示的字体大小 */
        color: #666;
    }
</style>
