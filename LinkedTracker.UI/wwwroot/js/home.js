new Vue({
    el: '#app',
    data:{
        games:[{text: 'A Link to the Past', value: 'lttp'}],
        roomName: '',
        game: 'lttp',
        roomUrl: null,
        errorMessage: ''
    },
    methods: {
        async createRoom() {
            var response = await post('/Room/Create', this.game)
            var data = await response.json();
            this.game = data.game;
            this.roomName = data.roomName;

            this.roomUrl = this.buildRoomUrl()
        },
        goRoom() {
            window.location = this.buildRoomUrl()
        },
        buildRoomUrl() {
            return `/${this.game}/${this.roomName}`
        }
    }
})