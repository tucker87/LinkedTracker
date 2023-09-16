import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import api from './api'
import mitt from 'mitt';

export default {
    install(app) {
        console.log('in roomhub', app)
        const roomHub = mitt()
        app.config.globalProperties.$roomHub = roomHub
        app.provide('roomHub', roomHub)

        const connection = new HubConnectionBuilder()
            .withUrl(`${api.baseURL}/room-hub`)
            .withAutomaticReconnect()
            .configureLogging(LogLevel.Information)
            .build()

        connection.onclose(() => start())

        connection.on('PoiTypeChange', (game, room, poiType) => {
            roomHub.emit('poi-type-changed', { game, room, poiType });
        })

        connection.on('PoiDoneChange', (poiIndex, isDone) => {
            roomHub.emit('poi-done-changed', { poiIndex, isDone });
        })

        let startedPromise = null
        function start() {
            return startedPromise ?? (startedPromise = connection.start().catch(err => {
                console.error('Failed to connect with hub', err)
                return new Promise((resolve, reject) =>
                    setTimeout(() => start().then(resolve).catch(reject), 5000))
            }))
        }

        start()

        roomHub.setPoiDone = (game, roomName, poiIndex, isDone) => {
            start()
                .then(() => connection.invoke('SetPoiDone', game, roomName, poiIndex, isDone))
                .catch(console.error)
        }

        roomHub.joinRoom = (game, roomName) => {
            start()
                .then(() => connection.invoke('JoinRoom', game, roomName))
                .catch(console.error)
        }
    }
}