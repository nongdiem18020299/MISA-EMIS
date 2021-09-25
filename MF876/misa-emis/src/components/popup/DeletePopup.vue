<template>
  <div class="popup-wrap d-flex">
    <div class="popup-container">
      <div class="popup-header">
        <div class="popup-title">Thông báo</div>
        <div class="icon-close" @click="closePopup"></div>
      </div>
      <div class="popup-content">
        <div class="popup-detail">
          Bạn có chắc chắn muốn xóa <span>{{ popupContent }}</span> này không?
        </div>
      </div>
      <div class="popup-footer d-flex">
        <div class="popup-btn close-btn" @click="closePopup">Đóng</div>
        <div class="popup-btn delete-btn" @click="deleteRecord">Đồng ý</div>
      </div>
    </div>
  </div>
</template>

<script>
import DepartmentApi from '../../api/components/department/DepartmentApi';
import EmployeeApi from "../../api/components/employee/EmployeeApi";
export default {
  name: "PopupDelete",
  props: {
    popupData: {},
    popupType: String,
  },
  data() {
    return {
      popupContent: "",
    };
  },
  created() {
    if (this.popupType == "department") {
      this.popupContent = "tổ bộ môn";
    }
    if (this.popupType == "employee") {
      this.popupContent = "cán bộ, giáo viên";
    }
  },
  methods: {
    closePopup() {
      this.$emit("closePopup");
    },
    deleteRecord() {
      if (this.popupType == "employee") {
        EmployeeApi.delete(this.popupData["employeeId"])
          .then((res) => {
            console.log(res);
            this.closePopup();
          })
          .catch((res) => {
            console.log(res);
            this.closePopup();
          });
      }
      if(this.popupType == 'department'){
        DepartmentApi.delete(this.popupData["departmentId"])
        .then((res)=>{
          console.log(res);
            this.closePopup();
        })
        .catch((res) => {
            console.log(res);
            this.closePopup();
          });
      }
    },
  },
};
</script>

<style>
@import "../../css/popup/deletePopup.css";
</style>