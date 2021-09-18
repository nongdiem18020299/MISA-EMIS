<template>
  <div id="app" class="d-flex">
    <sidebar></sidebar>
    <employee-page></employee-page>
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
  }
}
</script>

<style>
@import "../src/css/common/common.css";
@import "../src/css/common/main.css";
</style>
