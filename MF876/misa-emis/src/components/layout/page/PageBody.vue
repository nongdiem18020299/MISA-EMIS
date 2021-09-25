<template>
  <div class="page-body d-flex">
    <div class="page-body-sidebar">
      <div class="b-sidebar-select d-flex" @click="isDropDidebar=!isDropDidebar">
        <div class="b-select-drop-icon"></div>
        <div class="b-select-title">Trường THCS MISA</div>
      </div>
      <div class="b-select-list" v-show="isDropDidebar">
        <ul
          class="list-item"
          v-for="(department, i) in departments"
          :key="i"
          @mouseleave="itemHover = null"
        >
          <li class="d-flex item" @mouseover="itemHover = i">
            <div class="b-select-item-title">
              <div class="item-text">{{ department.departmentName }}</div>
            </div>
            <div
              v-show="itemHover == i"
              class="item-tool-icon"
              @click="
                openItemTool(department);
                itemSelected = i;
              "
            ></div>
          </li>
        </ul>
        <div
          v-click-outside="closeSidebarTool"
          v-if="openOption == true"
          class="sidebar-tool"
          v-bind:style="{ top: itemSelected * 35 + 'px' }"
        >
          <div class="tool-row d-flex" @click="openFormD('put')">
            <div class="tool-edit-icon"></div>
            <div class="tool-title" >Sửa</div>
          </div>
          <div class="tool-row d-flex">
            <div class="tool-delete-icon"></div>
            <div class="tool-title" @click="deleteDepartment">Xóa</div>
          </div>
        </div>
      </div>
      <div class="b-add-department d-flex"
      @click="openFormD('post')"
      >
        <div class="b-add-icon"></div>
        <div class="b-add-department-title">Thêm tổ bộ môn</div>
      </div>
    </div>
    <div class="page-body-content">
      <div class="page-body-header d-flex">
        <div class="b-header-left">
          <div class="search-tool">
            <input
              class="search-input"
              type="text"
              placeholder="Nhập Số hiệu cán bộ hoặc Tên cán bộ để tìm kiếm,..."
            />
            <div class="icon-search"></div>
          </div>
        </div>
        <div class="b-header-right">
          <button @click="openForm(employee, 'post')" class="add-btn">
            Thêm
          </button>
          <div class="more-tool-btn"></div>
        </div>
      </div>
      <div class="page-body-table">
        <page-table
          @openForm="openForm"
          @deleteItem="deleteItem"
          :departments="departments"
          :rooms="rooms"
          :subjects="subjects"
        ></page-table>
      </div>
      <div class="page-body-footer d-flex">
        <div class="b-footer-left flex-left">
          <div class="select-page d-flex">
            <div class="icon-first-page icon-paging"></div>
            <div class="icon-prev-page icon-paging"></div>
            <div class="page-number">
              <input type="text" class="page-number-input" value="2" />
            </div>
            <div class="icon-next-page icon-paging"></div>
            <div class="icon-last-page icon-paging"></div>
          </div>
          <div class="page-detail flex-left">
            <b>1/3</b> trang (<b>138</b> bản ghi)
          </div>
        </div>
        <div class="b-footer-right flex-right">
          <div class="back-btn">Quay lại</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import EmployeeApi from "../../../api/components/employee/EmployeeApi";
import PageTable from "./PageTable.vue";
export default {
  components: { PageTable },
  name: "PageBody",
  data() {
    return {
      newEmployeeCode: "",
      employee: {},
      itemHover: null,
      openOption: false,
      itemSelected: null,
      department: {},
      isDropDidebar: false,
    };
  },
  props: {
    departments: [],
    rooms: [],
    subjects: [],
  },
  created() {
    this.getNewEmployeeCode();
  },
  methods: {
    openForm(employee, formState) {
      if (!employee["employeeCode"]) {
        employee["employeeCode"] = this.newEmployeeCode;
      }
      this.$emit("openForm", employee, formState);
    },
    openFormD(formState) {
      this.$emit("openFormD", this.department, formState);
      this.openOption = false;
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
    deleteDepartment(){
      this.$emit("deleteItem", this.department, 'department');
    },
    deleteItem(employee) {
      this.$emit("deleteItem", employee, 'employee');
    },
    closeSidebarTool() {
      if (this.openOption && this.itemSelected != this.itemHover) {
        this.openOption = false;
      }
    },
    openItemTool(department) {
      this.openOption = true;
      this.department = department;
    },
  },
};
</script>

<style scoped>
@import "../../../css/layout/page/pageBody.css";
@import "../../../css/layout/page/pageBodyHeader.css";
@import "../../../css/layout/page/pageBodyTable.css";
@import "../../../css/layout/page/pageBodySidebar.css";
@import "../../../css/layout/page/pageBodyFooter.css";
</style>
