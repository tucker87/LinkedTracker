new Vue({
    el: '#app',
    data: window.vm,
    methods: {
        setPassword() {
            post(`/Room/SetPassword/${this.Room.Game}/${this.Room.RoomName}/${this.Room.Password}`)
        }
    }
})