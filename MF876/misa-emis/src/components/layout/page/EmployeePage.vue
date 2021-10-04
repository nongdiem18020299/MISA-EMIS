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
      :employees="employees"
      :newEmployeeCode="newEmployeeCode"
    ></page-body>
    <employee-dialog
      v-if="isOpenForm"
      @closeForm="
        isOpenForm = false;
        getNewEmployeeCode();
        loadData();
      "
      :Employee="employee"
      :departments="departments"
      :subjects="subjects"
      :rooms="rooms"
      :formState="formState"
    ></employee-dialog>
    <delete-popup
      v-if="isDelete"
      @closePopup="
        isDelete = false;
        getNewEmployeeCode();
        loadDepartment();
        loadData();
      "
      :popupData="popupData"
      :popupType="popupType"
    >
    </delete-popup>
    <department-dialog
      v-if="isOpenFormD"
      :department="department"
      :formState="formStateD"
      @closeFormDepartment="
        isOpenFormD = false;
        loadDepartment();
      "
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
import DepartmentDialog from "../../dialog/DepartmentDialog.vue";
import EmployeeApi from "@/api/components/employee/EmployeeApi.js";
// import moment from "moment";
export default {
  name: "EmployeePage",
  components: {
    TheHeader,
    PageBody,
    EmployeeDialog,
    DeletePopup,
    DepartmentDialog,
  },
  data() {
    return {
      isOpenForm: false,
      employee: [],
      departments: [],
      rooms: [],
      subjects: [],
      isDelete: false,
      formState: "",
      isOpenFormD: false,
      formStateD: "",
      department: {},
      popupType: "",
      popupData: "",
      isLoadData: false,
      employees: [],
      newEmployeeCode: "",
    };
  },
  created() {
    this.loadDepartment();
    this.loadRoom();
    this.loadSubject();
    this.loadData();
    this.getNewEmployeeCode();
  },
  methods: {
    openForm(employee, formState) {
      this.isOpenForm = true;
      this.employee = employee;
      this.formState = formState;
    },
    openFormD(department, formState) {
      this.isOpenFormD = true;
      this.department = department;
      this.formStateD = formState;
    },
    getNewEmployeeCode() {
      EmployeeApi.getFilter("NewEmployeeCode")
        .then((res) => {
          this.newEmployeeCode = res.data;
          console.log(res.data);
        })
        .catch((res) => {
          console.log(res.data);
        });
    },
    /**
     * Hàm load dữ liệu nhân viên
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadData() {
      var param = {
        DepartmentId: null,
        EmployeeFilter: null,
      };
      EmployeeApi.getFilter('EmployeeFilter', param)
        .then((res) => {
          this.formatData(res.data);
          console.log(res.data);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    formatData(data) {
      for (var employee of data) {
        if (employee["roomList"]) {
          employee["roomIdList"] = employee["roomList"].split(";");
          // console.log(employee["roomNameList"]);
        }
        if (employee["subjectList"]) {
          employee["subjectIdList"] = employee["subjectList"].split(";");
          // console.log(employee["subjectNameList"]);
        }

        for (var department of this.departments) {
          if (employee["departmentId"] == department["departmentId"]) {
            employee["departmentName"] = department["departmentName"];
          }
        }
        employee["roomNameList"] = [];
        for (var room of this.rooms) {
          for (var i in employee["roomIdList"]) {
            if (employee["roomIdList"][i] == room["roomId"]) {
              employee["roomNameList"].push(room["roomName"]);
              // employee["listRoomId"].push(room["roomId"]);
            }
          }
        }
        employee["subjectNameList"] = [];
        for (var subject of this.subjects) {
          for (var j in employee["subjectIdList"]) {
            if (employee["subjectIdList"][j] == subject["subjectId"]) {
              employee["subjectNameList"].push(subject["subjectName"]);
              // employee["listSubjectId"].push(subject["subjectId"]);
            }
          }
        }

        if (employee["workStatus"] == 1) {
          employee["workStatus"] = true;
        } else {
          employee["workStatus"] = false;
        }
        if (employee["trainingStatus"] == 1) {
          employee["trainingStatus"] = true;
        } else {
          employee["trainingStatus"] = false;
        }
        if(!employee["dayOff"]){
           employee["dayOff"] = new Date();
        } else{
          employee["dayOff"] = new Date(employee["dayOff"]);
        }
      }

      this.employees = data;
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
      this.isDelete = true;
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