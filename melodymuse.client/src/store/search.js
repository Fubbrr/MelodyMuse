// store/search.js
const state = () => ({
    searchType: 'songs', // Ĭ����������
    searchResults: [] // Ĭ���������Ϊ������
});

const mutations = {
    setSearchType(state, type) {
        state.searchType = type;
    },
    setSearchResults(state, results) {
        state.searchResults = results;
    }
};

const actions = {
    updateSearchType({ commit }, type) {
        commit('setSearchType', type);
    },
    updateSearchResults({ commit }, results) {
        commit('setSearchResults', results);
    }
};

const getters = {
    searchType: (state) => state.searchType,
    searchResults: (state) => state.searchResults
};

export default {
    namespaced: true,
    state,
    mutations,
    actions,
    getters
};
