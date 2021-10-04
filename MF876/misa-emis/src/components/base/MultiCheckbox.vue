<template>
  <div class="form-dropdown">
    <div class="form-multi-select d-flex" v-bind:class="{'onFocus': onFocus}">
      <div class="list-item-selected d-flex">
        <div
          class="item-selected"
          v-for="(itemSelected, j) in modelValue"
          :key="j"
          v-show="j < limit"
        >
          {{ itemSelected }}
          <div class="clear-select" @click="removeItem(itemSelected)"></div>
        </div>
      </div>
      <div class="list-item-input" >
        <input :type="type" @focus="onFocus=true" @focusout="onFocus=false"/>
      </div>
    </div>
    <div class="count-item d-flex" v-if="modelValue.length > limit">
      <div class="dot">...</div>
      <div class="amount-selected">{{ modelValue.length }}</div>
    </div>
    <div
      @click="openSelectList"
      v-bind:class="[{ 'dropdown-icon-rotage': isDrop }, 'dropdown-icon']"
    ></div>
    <ul class="select-list" v-if="isDrop" v-click-outside="closeSelectList">
      <li class="d-flex" @click="selectAll()">
        <div class="drop-item-checkbox">
          <base-checkbox
            :ref="'checkAll'"
            :isChecked="isCheckAll()"
          ></base-checkbox>
        </div>
        <div class="list-item-content">Tất cả</div>
      </li>
      <li
        class="d-flex"
        v-for="(item, i) in selectList"
        :key="i"
        @click="selectItem(item, i)"
      >
        <div class="drop-item-checkbox">
          <base-checkbox
            :isChecked="isChecked(item)"
            :ref="`checkboxItem${i}`"
          ></base-checkbox>
        </div>
        <div class="list-item-content">{{ item[nameDrop + "Name"] }}</div>
      </li>
    </ul>
  </div>
</template>

<script>
import BaseCheckbox from "./BaseCheckbox.vue";
export default {
  components: { BaseCheckbox },
  name: "MultiCheckbox",
  props: {
    selectedItem: [],
    type: {
      type: String,
      default: "text",
    },
    selectList: [],
    nameDrop: String,
    limit: Number,
  },
  data() {
    return {
      isDrop: false,
      isCheckMark: [],
      modelValue: [],
      onFocus: false,
    };
  },
  methods: {
    selectAll() {
      console.log(this.$refs["checkAll"].isChecked);
      if (this.$refs["checkAll"].isChecked) {
        this.modelValue = [];
      } else {
        this.modelValue = this.selectList.map(
          (element) => element[this.nameDrop + "Name"]
        );
      }
    },
    isCheckAll() {
      if (this.modelValue.length == this.selectList.length) return true;
      return false;
    },
    removeItem(itemSelected) {
      this.modelValue.splice(this.modelValue.indexOf(itemSelected), 1);
    },
    openSelectList() {
      if (this.isDrop) {
        this.isDrop = false;
      } else {
        this.isDrop = true;
      }
    },
    selectItem(item, i) {
      let key = this.nameDrop + "Name";
      if (this.isChecked(item)) {
        this.modelValue = this.modelValue.filter(
          (element) => element != item[key]
        );
        this.isCheckMark[i] = false;
      } else {
        this.modelValue.push(item[key]);
        this.isCheckMark[i] = true;
      }
    },
    closeSelectList(){
      if(this.isDrop){
        this.isDrop = false;
      }
    },
    isChecked(item) {
      for (var j in this.modelValue) {
        if (this.modelValue[j] == item[this.nameDrop + "Name"]) return true;
      }
      return false;
    },
  },
  created() {
    this.modelValue = this.selectedItem;
  },
  watch: {
    modelValue(){
      this.$emit("update:selectedItem", this.modelValue);
    }
  },
};
</script>
<style scoped>
@import "../../css/base/multiCheckbox.css";
</style>
