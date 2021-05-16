import 'bootstrap/dist/css/bootstrap.css'
import 'devextreme/dist/css/dx.light.css';

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

const app = createApp(App);

app.use(router);
app.mount('#app')
