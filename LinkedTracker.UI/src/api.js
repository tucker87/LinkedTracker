import axios from 'axios'
const baseUrl = 'https://localhost:5001'
axios.defaults.baseURL = baseUrl;

export default {
    baseURL: baseUrl,
    createRoom: game => 
        axios.post(`/Room/Create?game=${game}`)
            .then(r => r.data),

    getRoom: (game, roomName) => 
        axios.get(`/Room/${game}/${roomName}`)
            .then(r => r.data),

    getPOIs: (game, pointOfInterestType) => 
        axios.get(`/POI/${game}/${pointOfInterestType}`)
            .then(r => r.data),
    
    setPOIs: request => 
        axios.patch(`/Room/SetPoiType`, request),

    setPassword: request =>
        axios.patch(`/Room/SetPassword`, request)
}