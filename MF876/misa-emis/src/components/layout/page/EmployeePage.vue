<template>
  <div id="employee-page">
    <the-header></the-header>
    <page-body
      @openForm="openForm"
      @deleteItem="deleteItem"
      @openFormD="openFormD"
      :departments="this.departments"
      :subjects="subjects"
      :rooms="rooms"
    ></page-body>
    <employee-dialog
      v-if="isOpenForm"
      @closeForm="isOpenForm = false"
      :Employee="employee"
      :departments="departments"
      :subjects="subjects"
      :rooms="rooms"
      :formState="formState"
    ></employee-dialog>
    <delete-popup
      v-if="isDelete"
      @closePopup="isDelete = false"
      :popupData="popupData"
      :popupType="popupType"
    >
    </delete-popup>
    <department-dialog
    v-if="isOpenFormD"
    :department="department"
    :formState="formStateD"
    @closeFormDepartment="isOpenFormD = false"
    ></department-dialog>
  </div>
</template>

<script>
import TheHeader from "../TheHeader.vue";
import PageBody from "./PageBody.vue";
import EmployeeDialog from "../../dialog/EmployeeDialog.vue";
import DepartmentApi from "@/api/components/department/DepartmentApi.js";
import RoomApi from "../../../api/components/room/RoomApi.js";
import SubjectApi from "../../../api/components/subject/SubjectApi.js";
import DeletePopup from "../../popup/DeletePopup.vue";
import DepartmentDialog from '../../dialog/DepartmentDialog.vue';
export default {
  name: "EmployeePage",
  components: { TheHeader, PageBody, EmployeeDialog, DeletePopup, DepartmentDialog },
  data() {
    return {
      isOpenForm: false,
      employee: [],
      departments: [],
      rooms: [],
      subjects: [],
      isDelete: false,
      formState:"",
      isOpenFormD : false,
      formStateD:"",
      department:{},
      popupType:"",
      popupData:"",
    };
  },
  created() {
    this.loadDepartment();
    this.loadRoom();
    this.loadSubject();
  },
  methods: {
    openForm(employee, formState) {
      this.isOpenForm = true;
      this.employee = employee;
      this.formState = formState;
    },
    openFormD(department, formState){
      this.isOpenFormD = true;
      this.department = department;
      this.formStateD = formState;
    },
    /**
     * Hàm load dữ liệu phòng ban, tổ bộ môn
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadDepartment() {
      DepartmentApi.getAll()
        .then((res) => {
          this.departments = res.data;
          console.log(res);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Hàm load dữ liệu phòng kho
     * CreateBy: NTDIEM(15/09/2021)
     */ loadRoom() {
      RoomApi.getAll()
        .then((res) => {
          this.rooms = res.data;
          console.log(res.data);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Hàm load dữ liệu môn học
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadSubject() {
      SubjectApi.getAll()
        .then((res) => {
          this.subjects = res.data;
          console.log(res.data);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    deleteItem(employee, popupType) {
      this.isDelete =true;
      this.popupData = employee;
      this.popupType = popupType;
      console.log(employee["employeeId"]);
    },
  },
};
</script>

<style scoped>
@import "../../../css/layout/page/employeePage.css";
</style>