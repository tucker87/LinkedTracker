import axios from 'axios'
const baseUrl = 'https://localhost:5001'

export default {
    createRoom: game => 
        axios.post(`${baseUrl}/Room/Create?game=${game}`)
            .then(r => r.data),

    getRoom: (game, roomName) => 
        axios.get(`${baseUrl}/Room/${game}/${roomName}`)
            .then(r => r.data),

    getPOIs: (game, pointOfInterestType) => 
        axios.get(`${baseUrl}/POI/${game}/${pointOfInterestType}`)
            .then(r => r.data),

    setPassword: request =>
        axios.post(`${baseUrl}/Room/SetPassword`, request)
}