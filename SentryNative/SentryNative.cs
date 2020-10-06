using System;
using System.Runtime.InteropServices;

namespace SentryNative
{
    public enum sentry_value_type_t
    {
        SENTRY_VALUE_TYPE_NULL,
        SENTRY_VALUE_TYPE_BOOL,
        SENTRY_VALUE_TYPE_INT32,
        SENTRY_VALUE_TYPE_DOUBLE,
        SENTRY_VALUE_TYPE_STRING,
        SENTRY_VALUE_TYPE_LIST,
        SENTRY_VALUE_TYPE_OBJECT,
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct sentry_value_u
    {
        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public ulong _bits;

        [FieldOffset(0)]
        public double _double;
    }

    public enum sentry_level_e
    {
        SENTRY_LEVEL_DEBUG = -1,
        SENTRY_LEVEL_INFO = 0,
        SENTRY_LEVEL_WARNING = 1,
        SENTRY_LEVEL_ERROR = 2,
        SENTRY_LEVEL_FATAL = 3,
    }

    public partial struct sentry_ucontext_s
    {
        //[NativeTypeName("EXCEPTION_POINTERS")]
        //public _EXCEPTION_POINTERS exception_ptrs;
    }

    public unsafe partial struct sentry_uuid_s
    {
        [NativeTypeName("char [16]")]
        public fixed sbyte bytes[16];
    }

    public partial struct sentry_envelope_s
    {
    }

    public partial struct sentry_options_s
    {
    }

    public partial struct sentry_transport_s
    {
    }

    public enum sentry_user_consent_t
    {
        SENTRY_USER_CONSENT_UNKNOWN = -1,
        SENTRY_USER_CONSENT_GIVEN = 1,
        SENTRY_USER_CONSENT_REVOKED = 0,
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("sentry_value_t")]
    public unsafe delegate sentry_value_u sentry_event_function_t([NativeTypeName("sentry_value_t")] sentry_value_u @event, [NativeTypeName("void *")] void* hint, [NativeTypeName("void *")] void* closure);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void sentry_logger_function_t([NativeTypeName("sentry_level_t")] sentry_level_e level, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("va_list")] sbyte* args, [NativeTypeName("void *")] void* userdata);

    public static unsafe partial class Methods
    {
        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_malloc", ExactSpelling = true)]
        [return: NativeTypeName("void *")]
        public static extern void* sentry_malloc([NativeTypeName("size_t")] UIntPtr size);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_free", ExactSpelling = true)]
        public static extern void sentry_free([NativeTypeName("void *")] void* ptr);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_incref", ExactSpelling = true)]
        public static extern void sentry_value_incref([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_decref", ExactSpelling = true)]
        public static extern void sentry_value_decref([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_refcount", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr sentry_value_refcount([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_freeze", ExactSpelling = true)]
        public static extern void sentry_value_freeze([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_is_frozen", ExactSpelling = true)]
        public static extern int sentry_value_is_frozen([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_null", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_null();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_int32", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_int32([NativeTypeName("int32_t")] int value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_double", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_double(double value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_bool", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_bool(int value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_string", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_string([NativeTypeName("const char *")] sbyte* value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_list", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_list();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_object", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_object();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_get_type", ExactSpelling = true)]
        public static extern sentry_value_type_t sentry_value_get_type([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_set_by_key", ExactSpelling = true)]
        public static extern int sentry_value_set_by_key([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("const char *")] sbyte* k, [NativeTypeName("sentry_value_t")] sentry_value_u v);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_remove_by_key", ExactSpelling = true)]
        public static extern int sentry_value_remove_by_key([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("const char *")] sbyte* k);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_append", ExactSpelling = true)]
        public static extern int sentry_value_append([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("sentry_value_t")] sentry_value_u v);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_set_by_index", ExactSpelling = true)]
        public static extern int sentry_value_set_by_index([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("size_t")] UIntPtr index, [NativeTypeName("sentry_value_t")] sentry_value_u v);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_remove_by_index", ExactSpelling = true)]
        public static extern int sentry_value_remove_by_index([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("size_t")] UIntPtr index);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_get_by_key", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_get_by_key([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("const char *")] sbyte* k);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_get_by_key_owned", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_get_by_key_owned([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("const char *")] sbyte* k);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_get_by_index", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_get_by_index([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("size_t")] UIntPtr index);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_get_by_index_owned", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_get_by_index_owned([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("size_t")] UIntPtr index);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_get_length", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr sentry_value_get_length([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_as_int32", ExactSpelling = true)]
        [return: NativeTypeName("int32_t")]
        public static extern int sentry_value_as_int32([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_as_double", ExactSpelling = true)]
        public static extern double sentry_value_as_double([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_as_string", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sentry_value_as_string([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_is_true", ExactSpelling = true)]
        public static extern int sentry_value_is_true([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_is_null", ExactSpelling = true)]
        public static extern int sentry_value_is_null([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_to_json", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* sentry_value_to_json([NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_event", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_event();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_message_event", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_message_event([NativeTypeName("sentry_level_t")] sentry_level_e level, [NativeTypeName("const char *")] sbyte* logger, [NativeTypeName("const char *")] sbyte* text);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_new_breadcrumb", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_value_new_breadcrumb([NativeTypeName("const char *")] sbyte* type, [NativeTypeName("const char *")] sbyte* message);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_value_to_msgpack", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* sentry_value_to_msgpack([NativeTypeName("sentry_value_t")] sentry_value_u value, [NativeTypeName("size_t *")] UIntPtr* size_out);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_event_value_add_stacktrace", ExactSpelling = true)]
        public static extern void sentry_event_value_add_stacktrace([NativeTypeName("sentry_value_t")] sentry_value_u @event, [NativeTypeName("void **")] void** ips, [NativeTypeName("size_t")] UIntPtr len);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_unwind_stack", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr sentry_unwind_stack([NativeTypeName("void *")] void* addr, [NativeTypeName("void **")] void** stacktrace_out, [NativeTypeName("size_t")] UIntPtr max_len);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_unwind_stack_from_ucontext", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr sentry_unwind_stack_from_ucontext([NativeTypeName("const sentry_ucontext_t *")] sentry_ucontext_s* uctx, [NativeTypeName("void **")] void** stacktrace_out, [NativeTypeName("size_t")] UIntPtr max_len);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_uuid_nil", ExactSpelling = true)]
        [return: NativeTypeName("sentry_uuid_t")]
        public static extern sentry_uuid_s sentry_uuid_nil();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_uuid_new_v4", ExactSpelling = true)]
        [return: NativeTypeName("sentry_uuid_t")]
        public static extern sentry_uuid_s sentry_uuid_new_v4();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_uuid_from_string", ExactSpelling = true)]
        [return: NativeTypeName("sentry_uuid_t")]
        public static extern sentry_uuid_s sentry_uuid_from_string([NativeTypeName("const char *")] sbyte* str);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_uuid_from_bytes", ExactSpelling = true)]
        [return: NativeTypeName("sentry_uuid_t")]
        public static extern sentry_uuid_s sentry_uuid_from_bytes([NativeTypeName("const char [16]")] sbyte* bytes);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_uuid_is_nil", ExactSpelling = true)]
        public static extern int sentry_uuid_is_nil([NativeTypeName("const sentry_uuid_t *")] sentry_uuid_s* uuid);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_uuid_as_bytes", ExactSpelling = true)]
        public static extern void sentry_uuid_as_bytes([NativeTypeName("const sentry_uuid_t *")] sentry_uuid_s* uuid, [NativeTypeName("char [16]")] sbyte* bytes);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_uuid_as_string", ExactSpelling = true)]
        public static extern void sentry_uuid_as_string([NativeTypeName("const sentry_uuid_t *")] sentry_uuid_s* uuid, [NativeTypeName("char [37]")] sbyte* str);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_envelope_free", ExactSpelling = true)]
        public static extern void sentry_envelope_free([NativeTypeName("sentry_envelope_t *")] sentry_envelope_s* envelope);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_envelope_get_event", ExactSpelling = true)]
        [return: NativeTypeName("sentry_value_t")]
        public static extern sentry_value_u sentry_envelope_get_event([NativeTypeName("const sentry_envelope_t *")] sentry_envelope_s* envelope);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_envelope_serialize", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* sentry_envelope_serialize([NativeTypeName("const sentry_envelope_t *")] sentry_envelope_s* envelope, [NativeTypeName("size_t *")] UIntPtr* size_out);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_envelope_write_to_file", ExactSpelling = true)]
        public static extern int sentry_envelope_write_to_file([NativeTypeName("const sentry_envelope_t *")] sentry_envelope_s* envelope, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_transport_new", ExactSpelling = true)]
        [return: NativeTypeName("sentry_transport_t *")]
        public static extern sentry_transport_s* sentry_transport_new([NativeTypeName("void (*)(sentry_envelope_t *, void *)")] IntPtr send_func);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_transport_set_state", ExactSpelling = true)]
        public static extern void sentry_transport_set_state([NativeTypeName("sentry_transport_t *")] sentry_transport_s* transport, [NativeTypeName("void *")] void* state);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_transport_set_free_func", ExactSpelling = true)]
        public static extern void sentry_transport_set_free_func([NativeTypeName("sentry_transport_t *")] sentry_transport_s* transport, [NativeTypeName("void (*)(void *)")] IntPtr free_func);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_transport_set_startup_func", ExactSpelling = true)]
        public static extern void sentry_transport_set_startup_func([NativeTypeName("sentry_transport_t *")] sentry_transport_s* transport, [NativeTypeName("int (*)(const sentry_options_t *, void *)")] IntPtr startup_func);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_transport_set_shutdown_func", ExactSpelling = true)]
        public static extern void sentry_transport_set_shutdown_func([NativeTypeName("sentry_transport_t *")] sentry_transport_s* transport, [NativeTypeName("int (*)(uint64_t, void *)")] IntPtr shutdown_func);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_transport_free", ExactSpelling = true)]
        public static extern void sentry_transport_free([NativeTypeName("sentry_transport_t *")] sentry_transport_s* transport);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_new_function_transport", ExactSpelling = true)]
        [return: NativeTypeName("sentry_transport_t *")]
        public static extern sentry_transport_s* sentry_new_function_transport([NativeTypeName("void (*)(const sentry_envelope_t *, void *)")] IntPtr func, [NativeTypeName("void *")] void* data);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_new", ExactSpelling = true)]
        [return: NativeTypeName("sentry_options_t *")]
        public static extern sentry_options_s* sentry_options_new();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_free", ExactSpelling = true)]
        public static extern void sentry_options_free([NativeTypeName("sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_transport", ExactSpelling = true)]
        public static extern void sentry_options_set_transport([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("sentry_transport_t *")] sentry_transport_s* transport);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_before_send", ExactSpelling = true)]
        public static extern void sentry_options_set_before_send([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("sentry_event_function_t")] IntPtr func, [NativeTypeName("void *")] void* data);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_dsn", ExactSpelling = true)]
        public static extern void sentry_options_set_dsn([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* dsn);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_dsn", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sentry_options_get_dsn([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_sample_rate", ExactSpelling = true)]
        public static extern void sentry_options_set_sample_rate([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, double sample_rate);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_sample_rate", ExactSpelling = true)]
        public static extern double sentry_options_get_sample_rate([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_release", ExactSpelling = true)]
        public static extern void sentry_options_set_release([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* release);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_release", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sentry_options_get_release([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_environment", ExactSpelling = true)]
        public static extern void sentry_options_set_environment([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* environment);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_environment", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sentry_options_get_environment([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_dist", ExactSpelling = true)]
        public static extern void sentry_options_set_dist([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* dist);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_dist", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sentry_options_get_dist([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_http_proxy", ExactSpelling = true)]
        public static extern void sentry_options_set_http_proxy([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* proxy);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_http_proxy", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sentry_options_get_http_proxy([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_ca_certs", ExactSpelling = true)]
        public static extern void sentry_options_set_ca_certs([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_ca_certs", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* sentry_options_get_ca_certs([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_debug", ExactSpelling = true)]
        public static extern void sentry_options_set_debug([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, int debug);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_debug", ExactSpelling = true)]
        public static extern int sentry_options_get_debug([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_logger", ExactSpelling = true)]
        public static extern void sentry_options_set_logger([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("sentry_logger_function_t")] IntPtr func, [NativeTypeName("void *")] void* userdata);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_auto_session_tracking", ExactSpelling = true)]
        public static extern void sentry_options_set_auto_session_tracking([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, int val);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_auto_session_tracking", ExactSpelling = true)]
        public static extern int sentry_options_get_auto_session_tracking([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_require_user_consent", ExactSpelling = true)]
        public static extern void sentry_options_set_require_user_consent([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, int val);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_require_user_consent", ExactSpelling = true)]
        public static extern int sentry_options_get_require_user_consent([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_symbolize_stacktraces", ExactSpelling = true)]
        public static extern void sentry_options_set_symbolize_stacktraces([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, int val);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_get_symbolize_stacktraces", ExactSpelling = true)]
        public static extern int sentry_options_get_symbolize_stacktraces([NativeTypeName("const sentry_options_t *")] sentry_options_s* opts);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_add_attachment", ExactSpelling = true)]
        public static extern void sentry_options_add_attachment([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_handler_path", ExactSpelling = true)]
        public static extern void sentry_options_set_handler_path([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_database_path", ExactSpelling = true)]
        public static extern void sentry_options_set_database_path([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_add_attachmentw", ExactSpelling = true)]
        public static extern void sentry_options_add_attachmentw([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const wchar_t *")] ushort* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_handler_pathw", ExactSpelling = true)]
        public static extern void sentry_options_set_handler_pathw([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const wchar_t *")] ushort* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_database_pathw", ExactSpelling = true)]
        public static extern void sentry_options_set_database_pathw([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, [NativeTypeName("const wchar_t *")] ushort* path);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_options_set_system_crash_reporter_enabled", ExactSpelling = true)]
        public static extern void sentry_options_set_system_crash_reporter_enabled([NativeTypeName("sentry_options_t *")] sentry_options_s* opts, int enabled);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_init", ExactSpelling = true)]
        public static extern int sentry_init([NativeTypeName("sentry_options_t *")] sentry_options_s* options);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_shutdown", ExactSpelling = true)]
        public static extern int sentry_shutdown();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_clear_modulecache", ExactSpelling = true)]
        public static extern void sentry_clear_modulecache();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_user_consent_give", ExactSpelling = true)]
        public static extern void sentry_user_consent_give();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_user_consent_revoke", ExactSpelling = true)]
        public static extern void sentry_user_consent_revoke();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_user_consent_reset", ExactSpelling = true)]
        public static extern void sentry_user_consent_reset();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_user_consent_get", ExactSpelling = true)]
        public static extern sentry_user_consent_t sentry_user_consent_get();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_capture_event", ExactSpelling = true)]
        [return: NativeTypeName("sentry_uuid_t")]
        public static extern sentry_uuid_s sentry_capture_event([NativeTypeName("sentry_value_t")] sentry_value_u @event);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_handle_exception", ExactSpelling = true)]
        public static extern void sentry_handle_exception([NativeTypeName("const sentry_ucontext_t *")] sentry_ucontext_s* uctx);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_add_breadcrumb", ExactSpelling = true)]
        public static extern void sentry_add_breadcrumb([NativeTypeName("sentry_value_t")] sentry_value_u breadcrumb);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_set_user", ExactSpelling = true)]
        public static extern void sentry_set_user([NativeTypeName("sentry_value_t")] sentry_value_u user);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_remove_user", ExactSpelling = true)]
        public static extern void sentry_remove_user();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_set_tag", ExactSpelling = true)]
        public static extern void sentry_set_tag([NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_remove_tag", ExactSpelling = true)]
        public static extern void sentry_remove_tag([NativeTypeName("const char *")] sbyte* key);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_set_extra", ExactSpelling = true)]
        public static extern void sentry_set_extra([NativeTypeName("const char *")] sbyte* key, [NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_remove_extra", ExactSpelling = true)]
        public static extern void sentry_remove_extra([NativeTypeName("const char *")] sbyte* key);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_set_context", ExactSpelling = true)]
        public static extern void sentry_set_context([NativeTypeName("const char *")] sbyte* key, [NativeTypeName("sentry_value_t")] sentry_value_u value);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_remove_context", ExactSpelling = true)]
        public static extern void sentry_remove_context([NativeTypeName("const char *")] sbyte* key);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_set_fingerprint", ExactSpelling = true)]
        public static extern void sentry_set_fingerprint([NativeTypeName("const char *")] sbyte* fingerprint);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_remove_fingerprint", ExactSpelling = true)]
        public static extern void sentry_remove_fingerprint();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_set_transaction", ExactSpelling = true)]
        public static extern void sentry_set_transaction([NativeTypeName("const char *")] sbyte* transaction);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_remove_transaction", ExactSpelling = true)]
        public static extern void sentry_remove_transaction();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_set_level", ExactSpelling = true)]
        public static extern void sentry_set_level([NativeTypeName("sentry_level_t")] sentry_level_e level);

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_start_session", ExactSpelling = true)]
        public static extern void sentry_start_session();

        [DllImport("sentryffi", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sentry_end_session", ExactSpelling = true)]
        public static extern void sentry_end_session();
    }
}
