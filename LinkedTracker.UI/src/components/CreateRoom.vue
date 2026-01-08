<template>
   <div>
      <div style="display: inline-block; vertical-align: top;">
         <h3>Create a Room!</h3>
         <div>
            <label>Game</label>
            <select v-model="game">
               <option v-for="game in games" :value="game.value" :key="game.text">{{ game.text }}</option>
            </select>
         </div>
         <button @click="createRoom">Create</button>
         <div>
            <a v-if="roomUrl != null" :href="roomUrl">Goto {{ roomUrl }}</a>
         </div>
      </div>
      <div style="display: inline-block;">
         <h3>Goto a room!</h3>
         <div>
            <label>Game</label>
            <select v-model="game">
               <option v-for="game in games" :value="game.value" :key="game.text">{{ game.text }}</option>
            </select>
         </div>
         <div>
            <label>Room Name</label>
            <input v-model="roomName">
         </div>
         <router-link :to="`ViewRoom/${game}/${roomName}`">Go</router-link>
         <!-- <button @click="goRoom">Go</button> -->
         <div>
            <span style="color: red">{{ errorMessage }}</span>
         </div>
      </div>
   </div>
</template>

<script>
import api from '../api'
export default {
   data: function () {
      return {
         games: [{ text: "A Link to the Past", value: "lttp" }],
         roomName: "",
         game: "lttp",
         roomUrl: null,
         errorMessage: ""
      };
   },
   methods: {
      async createRoom() {
         var data = await api.createRoom(this.game)
         this.game = data.game;
         this.roomName = data.roomName;

         // this.roomUrl = this.buildRoomUrl();
      }
   }
};
</script>

<style scoped></style>
