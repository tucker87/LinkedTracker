import Vue from 'vue'
import App from './App.vue'
import router from './router'
import RoomHub from './room-hub'


Vue.config.productionTip = false

Vue.use(RoomHub)

window.app = new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
