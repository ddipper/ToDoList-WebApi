import { createApp } from 'vue'

import { createPinia } from 'pinia'
import { useUserStore } from "@/stores/UserStore.js";

import 'vuetify/styles'
import { createVuetify } from 'vuetify'
//import * as components from 'vuetify/components'
import { VBtn } from 'vuetify/components/VBtn'
import { VIcon } from 'vuetify/components/VIcon'
import { VForm } from 'vuetify/components/VForm'
import {  VTextField } from 'vuetify/components/VTextField'
import * as directives from 'vuetify/directives'
import { aliases, mdi } from 'vuetify/iconsets/mdi'

import router from './router.js'
import App from './App.vue'

import './assets/main.css'

const vuetify = createVuetify({
    components:{
        //...components,
        VBtn,
        VIcon,
        VForm,
        VTextField,
    },
    directives,
    icons: {
        defaultSet: 'mdi',
        aliases,
        sets: {
            mdi,
        },
    },
    theme: {
        defaultTheme: 'dark',
    }
});

const app = createApp(App)

const pinia = createPinia()
app.use(pinia)

//const userStore = useUserStore()


app.use(router)
app.use(vuetify)

app.mount('#app')
