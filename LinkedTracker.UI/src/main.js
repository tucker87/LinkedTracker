import { createApp, h } from 'vue'
import App from './App.vue'
import router from './router'
import RoomHub from './room-hub'

window.app = createApp({
  render: () => h(App),
})

window.app.use(router)
window.app.use(RoomHub)
window.app.mount('#app')
