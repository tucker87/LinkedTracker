<template>
  <div class="map-wrapper">
    <img id="map" :src="imgSrc">
    <poi
      v-for="point in points"
      :key="point.Index"
      :point="point"
      :map-x-scale="calcXScale()"
      :map-y-scale="calcYScale()"
    ></poi>
  </div>
</template>

<script>
import poi from "./POI.vue";
const pDiff = (a, b) => Math.abs(a - b) / a;
export default {
  components: { poi },
  props: ["points", "imgSrc"],
  data: function() {
    return {
      srcHeight: 0,
      srcWidth: 0,
      currHeight: 0,
      currWidth: 0
    };
  },
  mounted() {
    this.$nextTick(function() {
      window.addEventListener("resize", this.updateCurrHeight);
      window.addEventListener("resize", this.updateCurrWidth);

      var map = new Image();

      map.onload = () => {
        this.srcHeight = map.height;
        this.srcWidth = map.width;

        this.updateCurrHeight();
        this.updateCurrWidth();
      };

      map.src = this.imgSrc;
    });
  },
  methods: {
    updateCurrHeight() {
      this.currHeight = document.getElementById("map").height;
    },
    updateCurrWidth() {
      this.currWidth = document.getElementById("map").width;
    },
    calcXScale() {
      return pDiff(this.srcHeight, this.currHeight);
    },
    calcYScale() {
      return pDiff(this.srcWidth, this.currWidth);
    }
  }
};
</script>

<style scoped>
.map-wrapper {
  position: relative;
  user-select: none;
}

#map {
  width: 100%;
}
</style>