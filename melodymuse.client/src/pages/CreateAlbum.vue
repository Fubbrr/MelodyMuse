<template>
    <header>
        <SimpleHeader />
    </header>
    <main>
        <newAlbum />
    </main>


</template>

<script>
    import newAlbum from "../components/newAlbum.vue";
    import SimpleHeader from "../components/SimpleHeader.vue";

    export default {
        components: {
            newAlbum,
            SimpleHeader
        },
        data() {
            return {

            }
        }
    }
</script>

<style>
    header {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        z-index: 1000;
    }

    footer {
        position: absolute;
        bottom: 0;
        left: 0;
        width: 100%;
        z-index: 1000;
    }

    main {
        margin-top: 60px; /* 或者 padding-top: 60px; */
        margin-bottom: 40px; /* 或者 padding-bottom: 40px; */
    }
</style>