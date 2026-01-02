importScripts('https://www.gstatic.com/firebasejs/9.23.0/firebase-app-compat.js');
importScripts('https://www.gstatic.com/firebasejs/9.23.0/firebase-messaging-compat.js');

// Firebase configuration (same as your web app)
const firebaseConfig = {
    apiKey: "AIzaSyAb6LoXNUUyx784OrnW_AebLoy_qNOjk6Y",
    authDomain: "sitesafe-17331.firebaseapp.com",
    projectId: "sitesafe-17331",
    storageBucket: "sitesafe-17331.firebasestorage.app",
    messagingSenderId: "672319473104",
    appId: "1:672319473104:web:9cfdbc3cc07892effda5d5",
    measurementId: "G-S5H2NQM7X6",
};

firebase.initializeApp(firebaseConfig);

const messaging = firebase.messaging();

messaging.onBackgroundMessage(function (payload) {
    const notificationTitle = payload.notification.title;
    const notificationOptions = { body: payload.notification.body };
    self.registration.showNotification(notificationTitle, notificationOptions);
});