<template>
  <div class="department-dialog d-flex">
    <div class="department-form">
      <div class="d-form-header">
        <div class="form-icon-question"></div>
        <div class="form-icon-close" @click="closeForm"></div>
        <div class="d-form-title">{{formTitle}}  tổ bộ môn</div>
      </div>
      <div class="d-form-content">
        <div class="form-row d-flex">
          <div class="form-item d-flex">
            <div class="form-item-label d-flex">Tổ bộ môn <span> *</span></div>
            <base-input
              :type="'text'"
              :modelValue.sync="department.departmentName"
            ></base-input>
            <!-- <div class="form-item-input"><input type="text" /></div> -->
          </div>
        </div>
        <div class="form-row01 d-flex">
          <div class="form-item01 d-flex">
            <div class="form-item-label d-flex">Ghi chú</div>
            <base-input :type="'text'"  :modelValue.sync="department.description"></base-input>
            <!-- <div class="form-item-input"><input type="text" /></div> -->
          </div>
        </div>
      </div>
      <div class="d-form-footer d-flex">
        <div class="close-btn form-footer-btn" @click="closeForm">Đóng</div>
        <div class="save-btn form-footer-btn" @click="saveForm">Lưu</div>
      </div>
    </div>
  </div>
</template>

<script>
import BaseInput from "../base/BaseInput.vue";
import DepartmentApi from "../../api/components/department/DepartmentApi";
export default {
  name: "DepartmentDialog",
  components: {
    BaseInput,
  },
  props: {
    department: {},
    formState: String,
  },
  data(){
    return{
      formTitle:"",
    }
  },
  methods: {
    setFormTitle(){
      if(this.formState == 'put'){
        this.formTitle = "Sửa";
      }
      else{
        this.formTitle = "Thêm";
      }
    },
    closeForm() {
      this.$emit("closeFormDepartment");
    },
    saveForm() {
      var departmentData = JSON.stringify(this.department);
      console.log(departmentData);
      if (this.formState == "post") {
        DepartmentApi.post(departmentData)
          .then((res) => {
            console.log(res);
          })
          .catch((res) => {
            console.log(res);
          });
      } else {
        DepartmentApi.put(this.department["departmentId"], departmentData)
          .then((res) => {
            console.log(res);
          })
          .catch((res) => {
            console.log(res);
          });
      }
      this.closeForm();
    },
  },
  created(){
    this.setFormTitle();
  }
};
</script>

<style scoped>
@import "../../css/dialog/departmentDialog.css";
</style>