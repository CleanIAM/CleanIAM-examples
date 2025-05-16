<script lang="ts">
	import { signin } from "$lib/stores/auth.svelte";
	import { onMount } from "svelte";
  
	onMount(async () => {
	  signin();
	});
  </script>
  