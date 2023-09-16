<template>
    <div v-for="item in items">{{ item }}</div>
</template>


<script>
    export default {
        props: ['items']
    }
</script>