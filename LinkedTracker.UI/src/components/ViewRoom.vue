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
    <game-map :points="pointsOfInterest" :img-src="imgSrc"></game-map>
  </div>
</template>

<script>
import api from '../api'
import gameMap from "@/components/GameMap.vue";

export default {
  props:['game', 'roomName'],
  data() {
    return {
      imgSrc: "/map2.png",
      room: {},
      pointsOfInterest: []
    }
  },
  created() {
    console.log(process.env)
    this.$roomHub.$on('poi-type-changed', this.onPoiTypeChanged)
  },
  mounted() {
    api.getRoom(this.game, this.roomName)
      .then(response => {
        this.room = response.room
        this.pointsOfInterest = response.pointsOfInterest
      })
  },
  components: {
    gameMap
  },
  methods: {
    setPassword() {
      api.setPassword({
        game: this.room.game,
        roomName: this.room.roomName,
        password: this.room.password
      })
    },
    async setPointsOfInterest() {
      await api.setPOIs({
        game: this.room.game,
        roomName: this.room.roomName,
        poiType: this.room.pointOfInterestType
      })
    },
    async onPoiTypeChanged(e) {
      this.room.pointOfInterestType = e.poiType

      await this.getPointsOfInterest()
    },
    async getPointsOfInterest() {
      var points = await api.getPOIs(this.room.game, this.room.pointOfInterestType)
      this.pointsOfInterest = points
    }
  }
};
</script>

<style>
</style>
