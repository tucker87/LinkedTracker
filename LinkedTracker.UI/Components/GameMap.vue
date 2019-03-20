<template>
    <div class="map-wrapper">
        <img class="map" :src="imgSrc"/>
        <poi    v-for="point in points"
                :key="point.Index"
                :point="point">
        </poi>
    </div>
</template>

<script>
    import poi from '../Components/PointOfInterest/POI.vue'

    module.exports = {
        components: {poi},
        props: ['points', 'imgSrc']
    }
</script>