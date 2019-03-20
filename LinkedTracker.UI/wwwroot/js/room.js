// import poi from '../dist/js/PointOfInterest/POI.js'
//import Vue from 'vue'
import 'babel-polyfill';
import gameMap from '../../Components/GameMap.vue'

window.app = new Vue({
    el: '#app',
    data: {
        imgSrc: '/img/map2.png',
        ...window.vm
    },
    components: {
        gameMap
	},
    methods: {
        setPassword() {
            post('/Room/SetPassword', { 
                game: this.Room.Game,
                roomName: this.Room.RoomName,
                password: this.Room.Password
            })
        },
        async getPointsOfInterest() {
            var response = await fetch(`/POI/${this.Room.Game}/${this.Room.PointOfInterestType}`)
            this.PointsOfInterest = await response.json()
        }
    }
})