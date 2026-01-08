import { createRouter, createWebHistory } from "vue-router";
import CreateRoom from "@/components/CreateRoom.vue";
import ViewRoom from "@/components/ViewRoom.vue";

const routes = [
   {
      path: "/",
      redirect: {
         name: "CreateRoom",
      },
   },
   {
      path: "/CreateRoom",
      name: "CreateRoom",
      component: CreateRoom,
   },
   {
      path: "/ViewRoom/:game/:roomName",
      name: "ViewRoom",
      component: ViewRoom,
      props: true,
   },
];

const router = createRouter({
   history: createWebHistory(import.meta.env.BASE_URL),
   routes,
});

export default router;
