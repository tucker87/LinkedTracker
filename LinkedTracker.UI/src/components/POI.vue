<template>
  <div
    @click="toggleDone"
    :class="['poi', {'done': point.isDone}]"
    :style="{
        top: calcPos(point.x, mapXScale),
        left: calcPos(point.y, mapYScale)
    }"
  ></div>
</template>

<script>
export default {
  props: ["point", "mapXScale", "mapYScale"],
  methods: {
    calcPos(x, scale) {
      return x + x * scale + "px";
    },
    toggleDone() {
      this.$emit('toggleDone', this.point)
    }
  }
};
</script>

<style scoped>
.poi {
  position: absolute;
  height: 20px;
  width: 20px;
  background-color: green;
  border: black solid 3px;
  margin-top: -10px;
  margin-left: -10px;
  cursor: pointer;
}
.done {
  background-color: gray;
}
</style>