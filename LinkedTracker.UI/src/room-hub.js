import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'
import api from './api'

export default {
    install(Vue) {
        const roomHub = new Vue()
        Vue.prototype.$roomHub = roomHub
       
        const connection = new HubConnectionBuilder()
            .withUrl(`${api.baseURL}/room-hub`)
            .configureLogging(LogLevel.Information)
            .build()

        connection.on('PoiTypeChange', (game, room, poiType) => {
            roomHub.$emit('poi-type-changed', {game, room, poiType});
        })

        connection.on('PoiDoneChange', (poiIndex, isDone) => {
            roomHub.$emit('poi-done-changed', {poiIndex, isDone});
        })

        let startedPromise = null
        function start() {
            startedPromise = connection.start().catch(err => {
                console.error('Failed to connect with hub', err)
                return new Promise((resolve, reject) =>
                    setTimeout(() => start().then(resolve).catch(reject), 5000))
            })
            return startedPromise
        }
        connection.onclose(() => start())

        start()

        roomHub.setPoiDone = (game, roomName, poiIndex, isDone) => {
            startedPromise
                .then(() => connection.invoke('SetPoiDone', game, roomName, poiIndex, isDone))
                .catch(console.error)
        }

        roomHub.joinRoom = (game, roomName) => {
            startedPromise
                .then(() => connection.invoke('JoinRoom', game, roomName))
                .catch(console.error)
        }
    }
}