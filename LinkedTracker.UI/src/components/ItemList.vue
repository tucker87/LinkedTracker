<template>
    <div v-for="(item, i) in items" @click="$emit('toggleCollected', i)">{{ item }}</div>
</template>

<script setup>
    const props = defineProps(['items'])
</script>