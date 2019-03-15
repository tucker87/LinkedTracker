// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

new Vue({
    el: '#app',
    data:{
        games:[{text: 'A Link to the Past', value: 'lttp'}],
        roomName: '',
        game: 'lttp',
        roomUrl: null
    },
    methods: {
        async createRoom() {
            var response = await post('/Room/Create', { game: this.game, roomName: this.roomName })
            var data = await response.json();
            debugger;
            if(created) {
                this.roomUrl = `/Room/${this.game}/${this.roomName}`
            }
        }
    }
})