// store/index.js
import { createStore } from 'vuex'
import configure from './configure'
import search from './search' // �����µ�����ģ��

const store = createStore({
    modules: {
        configure,
        search // ע������ģ��
    }
})

export default store
