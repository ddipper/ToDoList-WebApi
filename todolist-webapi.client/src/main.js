import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import Login from './components/Login.vue'

import './assets/main.css'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {path: '/', name: 'app', component: App},
        {path: '/login', name: 'login', component: Login}
    ]
})

const app = createApp(App)

app.use(router)

app.mount('#app')
