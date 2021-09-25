<template>
  <div class="checkbox" v-bind:class="{ checkmark:isCheckedValue }">
    <input type="checkbox" :value="isChecked" :checked="isCheckedValue"  @click="updateInput" />
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
          isCheckedValue: this.isChecked,
      }
  },
  methods: {
    updateInput(event) {
        this.isCheckedValue = event.target.checked ;
      this.$emit("update:isChecked", event.target.checked);
    },
  }
};
</script>

<style>
</style>