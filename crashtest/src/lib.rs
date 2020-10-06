#[no_mangle]
pub unsafe extern "C" fn rust_crash_test() {
    println!("Crashing...");
    let test: *mut i32 = std::ptr::null_mut();
    *test = 0;
}
