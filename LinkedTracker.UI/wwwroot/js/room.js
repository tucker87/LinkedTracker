window.app = new Vue({
    el: '#app',
    data: window.vm,
    methods: {
        setPassword() {
            post('/Room/SetPassword', { 
                game: this.Room.Game,
                roomName: this.Room.RoomName,
                password: this.Room.Password
            })
        },
        getPointsOfInterest() {
            fetch(`/POI/${this.Room.Game}/${this.Room.PointOfInterestType}`)
        }
    }
})