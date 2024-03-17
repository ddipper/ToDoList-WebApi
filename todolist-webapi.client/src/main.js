import { createApp } from 'vue'

import { createPinia } from 'pinia'

import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import { aliases, mdi } from 'vuetify/iconsets/mdi'

import router from './router.js'
import App from './App.vue'

import './assets/main.css'

const vuetify = createVuetify({
    components:{
        ...components,
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

app.use(router)
app.use(vuetify)

app.mount('#app')
