<template>
  <div>
    <div>
      <span>{{ room.roomName }}</span>
    </div>
    <div>
      <input v-model="room.password">
    </div>
    <div>
      <button @click="setPassword">Set Password</button>
    </div>
    <div>
      <label>Point of Interest Type</label>
      <select @change="setPointsOfInterest" v-model="room.pointOfInterestType">
        <option value="Randomizer">Randomizer</option>
      </select>
    </div>
    <game-map :points="pointsOfInterest" :="{ imgSrc, game, roomName }" @createPoint="createPoint"></game-map>
    <item-list :="{ items }"></item-list>
  </div>
</template>


<script setup>
import { ref, onMounted, inject } from "vue"
import api from '../api'
import gameMap from "@/components/GameMap.vue";
import itemList from "@/components/ItemList.vue";
const roomHub = inject('roomHub')

const props = defineProps(['game', 'roomName'])
const game = ref(props.game)
const roomName = ref(props.roomName)

const imgSrc = "/map2.png"
let room = ref({})
let pointsOfInterest = ref([])
let items = ref([])

onMounted(async () => {
  var response = await api.getRoom(game.value, roomName.value)
  room.value = response.room
  pointsOfInterest.value = response.room.pointsOfInterest
  items = response.room.items

  roomHub.joinRoom(game.value, roomName.value)
})

const setPassword = () => api.setPassword({
  game: room.value.game,
  roomName: room.value.roomName,
  password: room.value.password
})

const setPointsOfInterest = async () => await api.setPOIs({
  game: room.value.game,
  roomName: room.value.roomName,
  poiType: room.value.pointOfInterestType
})

const createPoint = p => pointsOfInterest.value.push(p)

roomHub.on('poi-type-changed', async e => {
  room.value.pointOfInterestType = e.poiType

  pointsOfInterest.value = await api.getPOIs(room.value.game, roomName.value)
})
roomHub.on('poi-done-changed', e => pointsOfInterest[e.poiIndex].isDone = e.isDone)

</script>

<style></style>
