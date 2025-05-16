/*
Handle the sign in process and authorization process for the user 
*/

import * as oidc from 'oidc-client-ts';
import { goto } from '$app/navigation';

oidc.Log.setLogger(console);

export const userManager = $state(
	new oidc.UserManager({
		authority: 'https://localhost:5000',
		scope: 'openid profile roles BE1',
		client_id: 'example-FE-client',
		redirect_uri: `${window.location.origin}/signin-callback`,
		response_type: 'code',
		userStore: new oidc.WebStorageStateStore({ store: window.localStorage }),
		automaticSilentRenew: true,
		monitorSession: true,
		loadUserInfo: true
	})
);

export async function getUser() {
	return await userManager.getUser();
}

export async function signin() {
	const user = await userManager.getUser();

	if (user) {
		await goto('/home');
		return;
	}

	return userManager.signinRedirect({});
}

export function signoutLocally() {
	return userManager.removeUser();
}

export function signout() {
	return userManager.signoutRedirect();
}
