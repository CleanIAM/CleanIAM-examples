<script lang="ts">
	import { goto } from '$app/navigation';
	import { getUser, signout, signoutLocally } from '$lib/stores/auth.svelte';
	import type { User } from 'oidc-client-ts';

	var user: User | null = $state(null);
	var authCheckResult: string | null = $state(null);
	var authCheckSuccess: boolean = $state(false);

	$effect(() => {
		(async () => {
			user = await getUser();
			console.log('user', user);
		})();
	});

	const logout = async () => {
		await signoutLocally();
		goto('/');
	};

	const checkAuthStatus = async () => {
		try {
			authCheckResult = null;

			const response = await fetch('https://localhost:5003/test', {
				headers: {
					Authorization: `Bearer ${user?.access_token}`
				}
			});

			authCheckSuccess = response.ok;
			if (authCheckSuccess) {
				const data = await response.json();
				authCheckResult = JSON.stringify(data, null, 2);
			} else {
				authCheckResult = `${response.status}`;
			}
		} catch (error) {
			authCheckSuccess = false;
			authCheckResult = `Error: ${error}`;
		}
	};
</script>

<div class="flex min-h-screen items-center justify-center bg-gray-50 p-6">
	<div class="w-full max-w-md rounded-xl bg-white p-8 text-center ring-1 shadow-xl ring-gray-200">
		<h1 class="mb-4 text-3xl font-semibold text-gray-900">Welcome</h1>
		<p class="text-lg text-green-600">Welcome back, {user?.profile.name}!</p>

		<div class="mt-6 mb-6">
			<button
				onclick={checkAuthStatus}
				class="rounded-lg bg-blue-500 px-4 py-2 font-semibold text-white shadow-md transition duration-300 hover:bg-blue-600 focus:ring-2 focus:ring-blue-400 focus:ring-offset-2 focus:outline-none"
			>
				Verify Authentication
			</button>
		</div>
		{#if authCheckResult}
			<div
				class={`mt-4 max-h-40 overflow-auto rounded-lg p-4 text-left ${authCheckSuccess ? 'border border-green-200 bg-green-50' : 'border border-red-200 bg-red-50'}`}
			>
				<pre
					class={`text-sm whitespace-pre-wrap ${authCheckSuccess ? 'text-green-800' : 'text-red-800'}`}>{authCheckResult}</pre>
			</div>
		{:else}
			<div
				class="mt-4 max-h-40 overflow-auto rounded-lg border border-gray-200 bg-gray-50 p-4 text-left"
			>
				<pre class="text-sm text-gray-800">No authentication check performed yet.</pre>
			</div>
		{/if}

		<div class="mt-6 space-x-4">
			<button
				onclick={logout}
				class="rounded-lg bg-red-500 px-4 py-2 font-semibold text-white shadow-md transition duration-300 hover:bg-red-600 focus:ring-2 focus:ring-red-400 focus:ring-offset-2 focus:outline-none"
				>Logout locally</button
			>
			<button
				onclick={signout}
				class="rounded-lg bg-red-600 px-4 py-2 font-semibold text-white shadow-md transition duration-300 hover:bg-red-700 focus:ring-2 focus:ring-red-500 focus:ring-offset-2 focus:outline-none"
				>Logout</button
			>
		</div>
	</div>
</div>
