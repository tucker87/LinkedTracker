new Vue({
    el: '#app',
    data: window.vm,
    methods: {
        setPassword() {
            post('/Room/SetPassword', { 
                game: this.Room.Game,
                roomName: this.Room.RoomName,
                password: this.Room.Password
            })
        }
    }
})