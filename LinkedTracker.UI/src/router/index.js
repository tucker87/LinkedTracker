import { createRouter, createWebHistory } from 'vue-router'
import CreateRoom from '@/components/CreateRoom'
import ViewRoom from '@/components/ViewRoom'

const routes = [
    {
        path: "/",
        redirect: {
            name: "CreateRoom"
        }
    },
    {
        path: '/CreateRoom',
        name: 'CreateRoom',
        // component: () => import('../components/CreateRoom.vue')
        component: CreateRoom
    },
    {
        path: '/ViewRoom/:game/:roomName',
        name: 'ViewRoom',
        // component: () => import('../components/ViewRoom.vue'),
        component: ViewRoom,
        props: true
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router
