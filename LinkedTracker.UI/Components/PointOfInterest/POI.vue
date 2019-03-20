<template>
    <div :class="['poi', {'done': point.isDone}]" 
    :style="{
        top: calcTop(point.x),
        left: calcLeft(point.y)
    }"></div>
</template>

<script>
    module.exports = {
        props: ['point'],
        methods: {
            calcTop(x) {
                console.log(document.getElementsByClassName('map')[0])
                return x + 'px';
            },
            calcLeft(y) {
                return y + 'px';
            }
        }
    }
</script>

<style scoped> 
    .poi {
        position: absolute;
        height: 20px;
        width: 20px;
        background-color: green;
        border: black solid 3px;
    }
    .done {
        background-color: gray;
    }
</style>