import { defineStore } from 'pinia'

export const useUserStore = defineStore("userStore", {
    state: () => {
        return {username: null }
    },
    actions: {
        setUsername(name){
            this.username = name;
        }
    }
})