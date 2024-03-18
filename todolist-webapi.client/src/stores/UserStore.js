import { defineStore } from 'pinia'

export const useUserStore = defineStore("userStore", {
    state: () => {
        return { username: localStorage.getItem('username') }
    },
    actions: {
        setUsername(name){
            this.username = name;
            localStorage.setItem('username', name);
        }
    }
})