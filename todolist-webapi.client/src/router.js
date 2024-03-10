import { createRouter, createWebHistory } from 'vue-router'

import App from './App.vue'
import Login from './components/Login.vue'
import Register from "./components/Register.vue"; 
import Notes from "./components/Notes.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {path: '/', name: 'app', component: App},
        {path: '/login', name: 'login', component: Login},
        {path: '/register', name: 'register', component: Register},
        {path: '/notes', name: 'notes', component: Notes}
    ]
})

export default router