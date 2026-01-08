import axios from 'axios'
const baseUrl = import.meta.env.VITE_API_BASE_URL

axios.defaults.baseURL = baseUrl;

export default {
   baseURL: baseUrl,
   createRoom: async game => (await axios.post(`/Room/Create?game=${game}`)).data,
   getRoom: async (game, roomName) => (await axios.get(`/Room/${game}/${roomName}`)).data,
   getPOIs: async (game, roomName) => (await axios.get(`/Room/GetPointsOfInterest/${game}/${roomName}`)).data,
   setPOIs: async request => await axios.patch(`/Room/SetPoiType`, request),
   setPassword: async request => await axios.patch(`/Room/SetPassword`, request)
}
