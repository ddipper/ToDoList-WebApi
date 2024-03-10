import { createRouter, createWebHistory } from 'vue-router'

import Login from './components/Login.vue'
import Register from "./components/Register.vue"; 
import Notes from "./components/Notes.vue";
import Home from "./components/Home.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {path: '/', name: 'Home', component: Home},
        {path: '/login', name: 'Login', component: Login},
        {path: '/register', name: 'Register', component: Register},
        {path: '/notes', name: 'Notes', component: Notes}
    ]
})

export default router