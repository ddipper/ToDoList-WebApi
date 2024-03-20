import { defineStore } from 'pinia'

export const useUserStore = defineStore("userStore", {
    state: () => {
        return { username: localStorage.getItem('username') }
    },
    actions: {
        setUsername(name){
            if(name != null) {
                this.username = name;
                localStorage.setItem('username', name);
                return;
            }
            this.username = null;
            localStorage.removeItem('username');
        }
    }
})