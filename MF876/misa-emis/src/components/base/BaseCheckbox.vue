<template>
  <div class="checkbox" v-bind:class="[{ checkmark:isCheckedValue },{'onFocus ': onFocus}]">
    <input type="checkbox" :value="isChecked" :checked="isCheckedValue"  @click="updateInput" @focus="onFocus =true" @focusout="onFocus =false" @keypress.enter="isCheckedValue= !isCheckedValue"/>
  </div>
</template>

<script>
export default {
  name: "BaseCheckbox",
  props: {
    isChecked: {
      type: [Boolean],
      default: false,
    },
  },
  data(){
      return{
          isCheckedValue:false,
          onFocus:false,
      }
  },
  created(){
    this.isCheckedValue = this.isChecked;
  },
  methods: {
    updateInput(event) {
        this.isCheckedValue = event.target.checked ;
      this.$emit("update:isChecked", event.target.checked);
    },
  },
  watch:{
    isChecked(){
      this.isCheckedValue = this.isChecked;
    },
    isCheckedValue(){
       this.$emit("update:isChecked", this.isCheckedValue);
    }
  }
};
</script>

<style>
</style>