import Vue from 'vue'
import Router from 'vue-router'
import CreateRoom from '@/components/CreateRoom'
import ViewRoom from '@/components/ViewRoom'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: "/",
            redirect: {
                name: "CreateRoom"
            }
        },
        {
            path: '/CreateRoom',
            name: 'CreateRoom',
            component: CreateRoom
        },
        {
            path: '/ViewRoom/:game/:roomName',
            name: 'ViewRoom',
            component: ViewRoom,
            props: true
        }
    ]
})
