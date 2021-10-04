<template>
  <div class="base-table">
    <table>
      <thead>
        <tr>
          <th class="col-check-box th-checkbox">
            <div class="check-box-btn">
              <base-checkbox :ref="'checkAll'"></base-checkbox>
            </div>
          </th>
          <th>Số hiệu cán bộ</th>
          <th>Họ và tên</th>
          <th>Số điện thoại</th>
          <th>Tổ bộ môn</th>
          <th>Môn dạy</th>
          <th title="Quản lý kho phòng">QL kho, phòng</th>
          <th title="Đào tạo quản lý thiết bị">Đào tạo QLTB</th>
          <th>Đang làm việc</th>
          <th class="tool-col"><div class="tool-col"></div></th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(employee, i) in employees"
          :key="i"
          v-bind:class="{ 'even-row': i % 2 != 0 }"
          @dblclick="openForm(employee)"
        >
          <td class="col-check-box">
            <div class="check-box-btn">
              <base-checkbox :ref="`checkboxItem${i}`"></base-checkbox>
            </div>
          </td>
          <td>
            <div :title="employee.employeeCode" class="text-cell">
              {{ employee.employeeCode }}
            </div>
          </td>
          <td>
            <div :title="employee.fullName" class="text-cell col-full-name">
              {{ employee.fullName }}
            </div>
          </td>
          <td>
            <div :title="employee.phoneNumber" class="text-cell">
              {{ employee.phoneNumber }}
            </div>
          </td>
          <td>
            <div :title="employee.departmentName" class="text-cell">
              {{ employee.departmentName }}
            </div>
          </td>
          <td>
            <div :title="employee.subjectNameList.join(', ')" class="text-cell">
              {{ employee.subjectNameList.join(', ') }}
            </div>
          </td>
          <td>
            <div :title="employee.roomNameList.join(', ')" class="text-cell">
              {{ employee.roomNameList.join(', ') }}
            </div>
          </td>
          <td>
            <div class="text-cell">
              <div
                class="check-icon"
                v-bind:class="{ 'is-checked': employee.trainingStatus }"
              ></div>
            </div>
          </td>
          <td>
            <div class="text-cell">
              <div
                class="check-icon"
                v-bind:class="{ 'is-checked': employee.workStatus }"
              ></div>
            </div>
          </td>
          <td class="tool-col">
            <div class="tool-table d-flex">
              <div class="edit-icon" @click="openForm(employee)"></div>
              <div class="remove-icon" @click="deleteItem(employee)"></div>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import BaseCheckbox from "@/components/base/BaseCheckbox";
export default {
  name: "PageTable",
  components: {
    BaseCheckbox,
  },
  data() {
    return {
      selectEmployee: [],
    };
  },
  props: {
    departments: [],
    subjects: [],
    rooms: [],
    employees: [],
  },
  created() {},
  methods: {
    openForm(employee) {
      this.$emit("openForm", employee, "put");
    },
    deleteItem(employee) {
      this.$emit("deleteItem", employee);
    },
  },
};
</script>

<style scoped>
@import "../../../css/layout/page/pageBodyTable.css";
@import "../../../css/common/common.css";
</style>