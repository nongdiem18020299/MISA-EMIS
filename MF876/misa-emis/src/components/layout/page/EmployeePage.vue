<template>
  <div id="employee-page">
    <the-header></the-header>
    <page-body
    @openForm="openForm"
    ></page-body>
    <employee-dialog
      v-if="isOpenForm"
      @closeForm="isOpenForm=false"
      :Employee="employee"
    ></employee-dialog>
  </div>
</template>

<script>
import TheHeader from "../TheHeader.vue";
import PageBody from "./PageBody.vue";
import EmployeeDialog from "../../dialog/EmployeeDialog.vue";
export default {
  name: "EmployeePage",
  components: { TheHeader, PageBody, EmployeeDialog },
  data(){
    return{
      isOpenForm:false,
      employee:[],
    }
  },
  methods:{
    openForm(employee){
      this.isOpenForm= true;
      this.employee = employee;
    }
  }
};
</script>

<style scoped>
@import "../../../css/layout/page/employeePage.css";
</style>