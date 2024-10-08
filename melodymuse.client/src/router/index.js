import { createRouter, createWebHistory } from "vue-router";
import Home from "../pages/Home.vue";
import MyMusic from "../pages/MyMusic.vue";
import Singer from "../pages/Singer.vue";
import SongList from "../pages/SongList.vue";
import Login from "../pages/Login.vue";
import Sign from "../pages/Sign.vue";
import SearchResultPage from "../pages/SearchResultPage.vue"; // ?????????????????????;
import UserManage from "../pages/UserManage.vue"; //?????????????????????
import SongInfoEdit from "../pages/SongInfo.vue";
import Check from "../pages/Check.vue";
import modify from "../pages/modify.vue";
import createAlbum from "../pages/CreateAlbum.vue";
import UploadSong from "../pages/UploadSong.vue";
import mediaplayer from "../pages/mediaplayer.vue";
import userSongShow from "../pages/userSongShow.vue";
import SingerDetail from "../pages/SingerDetail.vue";
import FollowedArtist from "../pages/FollowedArtist.vue";
import Test from "@/pages/test.vue";
import AlbumDetail from "../pages/AlbumDetail.vue";
import CollectedSong from "../pages/CollectedSong.vue";
import CollectedAlbum from "../pages/CollectedAlbum.vue";
import SonglistDetail from "@/pages/SonglistDetail.vue";
import RankSongs from "../pages/RankSongs.vue";
import RankArtists from "../pages/RankArtists.vue";
import TheAside from "@/components/TheAside.vue";
import NotFound from "@/pages/NotFound.vue";
import Statistics from "@/pages/Statistics.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: Home,
  },
  {
    path: "/user/:status",
    children: [
      {
        path: "personal-info",
        name: "modify",
        component: modify,
      },
      {
        path: "check-song",
        name: "Check",
        component: Check,
      },
      {
        path: "usermanage",
        name: "usermanage", //?????????????????????
        component: UserManage, //?????????????????????
      },
      {
        path: "uploadSong",
        name: "UploadSong",
        component: UploadSong,
      },
      {
        path: "song-info",
        name: "song-info",
        component: SongInfoEdit,
      },
      {
        path: "statistics",
        name: "statistics",
        component: Statistics,
      },
    ],
  },
  {
    path: "/createAlbum",
    name: "createAlbum",
    component: createAlbum,
  },
  {
    path: "/sign",
    name: "Sign",
    component: Sign,
  },
  {
    path: "/singer",
    name: "singer",
    component: Singer,
  },
  {
    path: "/song-list",
    name: "song-list",
    component: SongList,
  },
  {
    path: "/login",
    name: "Login",
    component: Login,
  },
  {
    path: "/register",
    name: "Register",
    component: () => import('@/pages/Register.vue'),
  },

  {
    path: "/mediaplayer/:songId/:songList",
    //eg:  /mediaplayer/1cd134c4-c/1cd134c4-c,6adb0c3a-c
    name: "mediaplayer",
    component: mediaplayer,
  },
  {
    //path: "/SingerDetail/",//调试用
    path: "/SingerDetail/:artistId",
    name: "SingerDetail",
    component: SingerDetail,
  },
  {
    path: "/FollowedArtist",
    name: "FollowedArtist",
    component: FollowedArtist,
  },
  {
    path: "/searchResultPage", // ???????��??????
    name: "search-result-page",
    component: SearchResultPage,
  },
  {
    path: "/ForgottenPassword",
    name: "ForgottenPassword",
    component: () => import('@/pages/ForgottenPassword.vue'),
  },
  {
    path: "/ranksongs",
    name: "ranksongs",
    component: RankSongs,
  },
  {
    path: "/rankartists",
    name: "rankartists",
    component: RankArtists,
  },
  {
    path: "/my-music",
    name: "userSongShow",
    component: userSongShow,
  },
  {
    path: "/test",
    name: "test",
    component: Test,
  },
  {
    path: "/AlbumDetail/:albumId",
    //path: "/AlbumDetail",//调试用
    name: "AlbumDetail",
    component: AlbumDetail,
  },
  {
    path: "/CollectedSong",
    name: "CollectedSong",
    component: CollectedSong,
  },
  {
    path: "/CollectedAlbum",
    name: "CollectedAlbum",
    component: CollectedAlbum,
  },
{
    path: "/SonglistDetail/:songListId",
    name: "SonglistDetail",
    component: SonglistDetail,
  },
  {
    path: "/:catchAll(.*)",
    name: "404",
    component: NotFound,
  },
];

const router = createRouter({
  history: createWebHistory(), // ??????? base URL
  routes,
});

export default router;
