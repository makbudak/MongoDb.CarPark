<template>
    <nav-menu></nav-menu>
    <div class="container">
        <router-view />
    </div>
</template>

<script>
    import NavMenu from './components/NavMenu.vue'

    export default {
        name: 'App',
        components: {
            NavMenu
        }
    }
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
    }
</style>
