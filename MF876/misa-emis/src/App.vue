<template>
  <div id="app" class="d-flex">
    <sidebar @sidebarCollapse="openSidebar"></sidebar>
    <employee-page  v-bind:class="{'wideBody' : isSidebarCollapse}"></employee-page>
  </div>
</template>

<script>
import EmployeePage from './components/layout/page/EmployeePage.vue'
import Sidebar from './components/layout/Sidebar.vue'

export default {
  name: 'App',
  components: {
    Sidebar,
    EmployeePage,
  },
  data() {
    return {
       isSidebarCollapse: true,
    }
  },
  methods:{
    openSidebar(isWide){
      this.isSidebarCollapse = !isWide;
    },
  }
}
</script>

<style>
@import "../src/css/common/common.css";
@import "../src/css/common/main.css";
</style>
